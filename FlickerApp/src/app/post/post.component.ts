import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { postdata } from '../models/postclass';
import { PostService } from '../service/post.service';
import UserService from '../service/user.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  posts: any = [
    {
      price: 34,
      message: "mahesh"
    },
    {

      price: 34,
      message: "mahesh"
    }
   
  ]
  go:postdata = new postdata();
  constructor(private js:PostService, private router:Router ) { }

  ngOnInit(): void {
  }
  Addpost(){
     this.js.Addpostdata(this.go);
     this.router.navigateByUrl('/showpost');
    //  this.go = new postdata();
    
  }
  // showpost(){
  //   this.js.Addpostdata(this.go)
  //   this.go = new postdata();
    
  // }

}
