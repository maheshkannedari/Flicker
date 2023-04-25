import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user';
import UserService from '../service/user.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  m:User = new User()
  constructor(private mk:UserService) { }
  
  ngOnInit(): void {
  }
  loginHandler(){
    this.mk.Registeruser(this.m);
  }
  

}
