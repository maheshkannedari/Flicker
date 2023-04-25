
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { postdata } from '../models/postclass';
import { User } from '../models/user';
import { createComponent } from '@angular/core';
import { ShowpostComponent } from '../showpost/showpost.component';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  gc:Array<postdata> = []
  constructor(private hc:HttpClient,
    private router: Router) { }

   Getpostdata():Observable<Array<postdata>>{
    return this.hc.get<Array<postdata>>("http://localhost:5098/api/Post");
   }
   Addpostdata(go:postdata){
          this.hc.post<postdata>("http://localhost:5098/api/Post",go)
          .subscribe(
            {
            next:(success)=>{console.log(success)},
            error:(error)=>console.log(error)
            }
          )
    }
}


