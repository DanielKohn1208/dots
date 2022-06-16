from django.urls import path

from . import views

urlpatterns = [
    path('', views.home, name='home'),
    path('register/', views.register, name='register'),
    path('logout/', views.userLogout, name='logout'),
    path('login/', views.userLogin, name='login'),
]
