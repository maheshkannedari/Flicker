import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { PostComponent } from './post/post.component';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { ShowpostComponent } from './showpost/showpost.component';
import { PostService } from './service/post.service';
import { ChatComponent } from './chat/chat.component';
import { FirstInterceptor } from './interceptors/first.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    PostComponent,
    CreateComponent,
    ShowpostComponent,
    ChatComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule
    
  ],
  providers: [PostService, 
  {
    provide:HTTP_INTERCEPTORS,
    useClass:FirstInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
