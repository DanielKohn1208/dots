from django.contrib import admin
from .models import Suggestion, Like, Comment

# Register your models here.
admin.site.register(Suggestion)
admin.site.register(Like)
admin.site.register(Comment)
