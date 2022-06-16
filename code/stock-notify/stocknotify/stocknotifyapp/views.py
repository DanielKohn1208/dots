from django.shortcuts import render
from .forms import RegisterForm, LoginForm
from stockHelper import sendRequest
from django.contrib import messages
from django.contrib.auth.models import User
from django.contrib.auth import authenticate, login, logout
from django.shortcuts import redirect
# Create your views here.


def home(request):
    return render(request, "stocknotifyapp/home.html", {})


def register(request):

    if request.method == 'POST':
        f = RegisterForm(request.POST)
        if f.is_valid():
            f.save()
            username = f.cleaned_data.get('username')
            password = f.cleaned_data.get('password1')
            user = authenticate(request, username=username, password=password)
            login(request, user)
            return redirect('home')
    else:
        f = RegisterForm()
    return render(request, 'stocknotifyapp/register.html', {'form': f})

def userLogout(request):
    if request.method == 'POST':
        logout(request)
    return redirect('home')

def userLogin(request):
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
                messages.error(request, "There is no user with this user name and/or password")

    else:
        f = LoginForm()
    return render(request, 'stocknotifyapp/login.html', {'form':f})


