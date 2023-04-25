import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateComponent } from '../create/create.component';
import { postdata } from '../models/postclass';
import { PostService } from '../service/post.service';
import UserService from '../service/user.service';


@Component({
  selector: 'app-showpost',
  templateUrl: './showpost.component.html',
  styleUrls: ['./showpost.component.css']
})
export class ShowpostComponent implements OnInit {
  gc:Array<postdata> = []
  constructor(private js:PostService) { 

    this.js.Getpostdata().subscribe((success)=>{
      this.gc = success;
    })
  }

  ngOnInit(): void {
  }

}
