import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatPageComponent } from './pages/chat-page/chat-page.component';
import { LoginComponent } from './pages/login/login.component';
import { LoginGuard } from './services/globalserv/login.guard';

const routes: Routes = [
  {path: 'login',component: LoginComponent,  },
  {path: '',redirectTo: 'login',pathMatch: 'full',},
  {path: 'chat-page',component: ChatPageComponent,canActivate:[LoginGuard]}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
