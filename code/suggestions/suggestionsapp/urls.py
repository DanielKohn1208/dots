from django.urls import path

from . import views

urlpatterns = [
    path('',views.home,name='home'),  
    path('register/',views.register,name='register'),  
    path('login/',views.auth_login,name='login'),  
    path('logout/',views.auth_logout ,name='logout'),  
    path('createsuggestion/',views.createSuggestion,name='createsuggestion'),  
    path('like/<int:suggestionId>/',views.like,name='like'),  
    path('unlike/<int:suggestionId>/',views.unlike,name='unlike'),  
    path('suggestion/<int:id>/',views.suggestion ,name='suggestion'),  
]
