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
export default class UserService {
  gc:Array<postdata> = []
  constructor(private hc:HttpClient,
    private router: Router) { }
  Registeruser(k:User){
    this.hc.post("http://localhost:5289/api/User/validate",k).subscribe(
    //(result)=>{ console.log("success"+JSON.stringify(result))  }
     {
       next:(result:any)=>{
                      this.router.navigateByUrl('/create');
                     console.log("success"+JSON.stringify((result)));
                     localStorage.setItem('token',result.token);
                   },
       error:(err)=>{console.log('error'+JSON.stringify(err))}
   }
   );
 }
 ValidateUser(u:User){
  this.hc.post<User>("http://localhost:5289/api/User/Register",u).subscribe(
  //(result)=>{ console.log("success"+JSON.stringify(result))  }
   {
     next:(result:any)=>{
                   console.log("success"+JSON.stringify((result)));
                   localStorage.setItem('token',result.token);
                 },
     error:(err)=>{console.log('error'+JSON.stringify(err))}
   }
   );
 }
 
}

// gc:Array<GoldOrnaments> = []
//     constructor(private Client:HttpClient) { }
//   // addOrnament(go:GoldOrnaments){
//   //   this.gc.push(go);
//   getOrnament():Observable<Array<GoldOrnaments>>{
//     return this.Client.get<Array<GoldOrnaments>>("http://localhost:5203/api/Gold");
//   }
//   addOrnament(go:GoldOrnaments){
//     this.Client.post<GoldOrnaments>("http://localhost:5203/api/Gold",go)
//     .subscribe(
//       {
//       next:(success)=>{console.log(success)},
//       error:(error)=>console.log(error)
//       }
//     )
//   }
// }
  
  
