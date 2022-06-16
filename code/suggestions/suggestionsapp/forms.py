from django import forms
from .models import Suggestion, Comment
from django.contrib.auth.models import User
from django.contrib.auth.forms import UserCreationForm


class CreateCommentForm(forms.ModelForm):
    class Meta:
        model = Comment
        fields = ['content']
    content = forms.CharField(
        label='Enter your comment',
        widget=forms.Textarea(
            attrs={'class': 'form-control', 'placeholder': 'Comment'}
        )
    )


class CreateSuggestionForm(forms.ModelForm):
    class Meta:
        model = Suggestion
        fields = ['title', 'description']
    title = forms.CharField(
        label='Enter Title',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'Title'}),
    )

    description = forms.CharField(
        label='Enter Descriptions',
        widget=forms.Textarea(
            attrs={'class': 'form-control', 'placeholder': 'Username'}),
    )


class LoginForm(forms.Form):
    username = forms.CharField(
        label='Enter Username',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'Username'}),
    )

    password = forms.CharField(
        label='Enter Password',
        widget=forms.PasswordInput(
            attrs={'class': 'form-control', 'placeholder': 'Password'}),
    )


class RegisterForm(UserCreationForm):
    class Meta:
        model = User
        fields = [
            'username', 'email', 'first_name', 'last_name', 'password1', 'password2',
        ]
    email = forms.EmailField(
        max_length=100,
        required=True,
        label='Your Email',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'Email'}),
    )
    first_name = forms.CharField(
        max_length=100,
        required=True,
        label='Enter First Name',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'First Name'}),
    )
    last_name = forms.CharField(
        max_length=100,
        required=True,
        label='Enter Last Name',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'Last Name'}),
    )
    username = forms.CharField(
        max_length=200,
        required=True,
        label='Enter Username',
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'placeholder': 'Username'}),
    )
    password1 = forms.CharField(
        label='Enter Password',
        required=True,
        widget=forms.PasswordInput(
            attrs={'class': 'form-control', 'placeholder': 'Password'}),
    )
    password2 = forms.CharField(
        required=True,
        label='Enter Password Again',
        widget=forms.PasswordInput(
            attrs={'class': 'form-control', 'placeholder': 'Password Again'}),
    )
