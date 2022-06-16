from django.db import models
from django.contrib.auth.models import User

# Create your models here.


class Suggestion(models.Model):
    title = models.CharField(max_length=90, unique=True, blank=False)
    description = models.CharField(max_length=1500, blank=False)
    STATUS_CHOICES = [
        ('IP', 'In Progress'),
        ('CL', 'Closed'),
        ('DO', 'Done'),
        ('OP', 'Open')
    ]
    status = models.CharField(
        max_length=2, choices=STATUS_CHOICES, default="OP")


class Like(models.Model):
    suggestion = models.ForeignKey(Suggestion, on_delete=models.CASCADE)
    creator = models.ForeignKey(User, on_delete=models.CASCADE)

    class Meta:
        unique_together = [['suggestion', 'creator']]


class Comment(models.Model):
    suggestion = models.ForeignKey(Suggestion, on_delete=models.CASCADE)
    creator = models.ForeignKey(User, on_delete=models.CASCADE)
    content = models.CharField(max_length=1500)
    datePosted = models.DateTimeField(auto_now_add=True)
