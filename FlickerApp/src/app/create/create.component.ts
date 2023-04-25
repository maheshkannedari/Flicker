import { Component, OnInit } from '@angular/core';
import { postdata } from '../models/postclass';
import UserService from '../service/user.service';
import { compileDeclareComponentFromMetadata } from '@angular/compiler';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
 
  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  Addpost(){
    //  this.js.Addpostdata(this.go);
    this.router.navigate(['addpost'])
  }
  // showpost(){
  //   // this.js.Addpostdata(this.go)
  //   // this.go = new postdata();
  //   this.router.navigate(['showpost'])
  // }

}

