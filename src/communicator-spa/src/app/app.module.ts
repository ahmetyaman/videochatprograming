import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlertifyService } from './services/globalserv/alertify.service';
import { AuthService } from './services/globalserv/auth.service';
import { LoginComponent } from './pages/login/login.component';
import { ChatPageComponent } from './pages/chat-page/chat-page.component';
import { LoginGuard } from './services/globalserv/login.guard';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatPageComponent,

 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [AlertifyService,AuthService,LoginGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
