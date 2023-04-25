import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import UserService from '../service/user.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  v :User = new User()
  constructor(private a:UserService) { }

  ngOnInit(): void {
  }
  RegisterHandler(){
    this.a.Registeruser(this.v);
  }
}
