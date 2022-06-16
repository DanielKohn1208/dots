from django.db import models
from django.contrib.auth.models import User

class WatchedStock(models.Model):
    watcher = models.ForeignKey(User, on_delete=models.CASCADE)
    stock_symbol = models.CharField(max_length=30) 



# Create your models here.
