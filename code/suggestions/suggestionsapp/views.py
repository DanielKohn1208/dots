from django.contrib import messages
from django.contrib.auth import authenticate, login, logout
from django.contrib.auth.decorators import login_required
from django.contrib.auth.models import User
from django.http import (HttpResponseBadRequest, HttpResponseNotFound,
                         HttpResponseRedirect)
from django.shortcuts import redirect, render, reverse

from .forms import (CreateCommentForm, CreateSuggestionForm, LoginForm,
                    RegisterForm)
from .models import Comment, Like, Suggestion


@login_required
def unlike(request, suggestionId):
    try:
        currentUser = request.user
        suggestion = Suggestion.objects.get(id=suggestionId)
        likeToRemove = Like.objects.get(
            creator=currentUser, suggestion=suggestion)
        likeToRemove.delete()
        return HttpResponseRedirect(reverse('suggestion', args=[suggestionId]))
    except:
        return HttpResponseBadRequest()


@login_required
def like(request, suggestionId):
    try:
        user = request.user
        suggestion = Suggestion.objects.get(id=suggestionId)
        like = Like(suggestion=suggestion, creator=user)
        like.save()
        return HttpResponseRedirect(reverse('suggestion', args=[suggestionId]))
    except:
        return HttpResponseBadRequest()


@login_required
def createSuggestion(request):
    suggestionId = None
    if request.method == 'POST':
        f = CreateSuggestionForm(request.POST)
        if f.is_valid():
            newSuggestion = f.save()
            suggestionId = newSuggestion.id
            title = f.cleaned_data.get('title')
            messages.success(
                request, f"Your suggestion \'{title}\' was successfully created")
            f = CreateSuggestionForm()

    else:
        f = CreateSuggestionForm()
    return render(request, "suggestionsapp/createsuggestion.html", {'form': f, "suggestionId": suggestionId})


def suggestion(request, id):
    try:
        suggestion = Suggestion.objects.get(id=id)
        totalLikes = len(Like.objects.filter(suggestion=suggestion))
        if request.method == 'POST' and request.user.is_authenticated:
            f = CreateCommentForm(request.POST)
            if f.is_valid():
                commentContent = f.cleaned_data.get('content')
                newComment = Comment(
                    content=commentContent, creator=request.user, suggestion=suggestion)
                newComment.save()
                f = CreateCommentForm()
            else:
                f = CreateCommentForm()
        else:
            f = CreateCommentForm()

        if request.user.is_authenticated:
            currentUser = request.user
            if len(Like.objects.filter(creator=currentUser, suggestion=suggestion)) == 0:
                hasLiked = False
            else:
                hasLiked = True
        else:
            hasLiked = False
        comments = Comment.objects.all().order_by('datePosted')
        return render(request, "suggestionsapp/suggestion.html", {'form': f, 'suggestion': suggestion, "totalLikes": totalLikes, "hasLiked": hasLiked, "comments": comments})
    except Suggestion.DoesNotExist:
        return HttpResponseNotFound()


def home(request):
    suggestions = Suggestion.objects.all()
    print(len(suggestions[0].like_set.all()))
    return render(request, "suggestionsapp/home.html", {'suggestions': suggestions})


def register(request):
    if request.method == 'POST':
        f = RegisterForm(request.POST)
        if f.is_valid():
            f.save()
            messages.success(request, 'Account created successfully')
            username = f.cleaned_data.get('username')
            password = f.cleaned_data.get('password1')
            user = authenticate(request, username=username, password=password)
            login(request, user)
            return redirect('home')
    else:
        f = RegisterForm()
    return render(request, 'suggestionsapp/register.html', {'form': f})


def auth_login(request):
    if request.method == 'POST':
        f = LoginForm(request.POST)
        if f.is_valid():
            username = f.cleaned_data.get('username')
            password = f.cleaned_data.get('password')

            user = authenticate(request, username=username, password=password)
            if user is not None:
                login(request, user)
                return redirect('home')
            else:
                return redirect('home')
        else:
            return render(request, 'suggestionsapp/login.html', {'form': f})

    else:
        f = LoginForm()
    return render(request, 'suggestionsapp/login.html', {'form': f})


def auth_logout(request):
    if request.method == 'POST':
        logout(request)
    return redirect('home')
