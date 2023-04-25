import { createComponent, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './chat/chat.component';
import { CreateComponent } from './create/create.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { PostComponent } from './post/post.component';
import { RegisterComponent } from './register/register.component';
import { ShowpostComponent } from './showpost/showpost.component';

const routes: Routes = [
  {path:"login", component:LoginComponent},
  {path:"register", component:RegisterComponent},
  {path:'create',component:CreateComponent},
  {path:'addpost', component:PostComponent},
  {path:'showpost', component:ShowpostComponent},
  {path:'chat', component:ChatComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
