import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/globalserv/auth.service';
import { PersonForLoginDto } from 'src/app/services/models/PersonForLoginDto';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService) {}

  model: PersonForLoginDto = new  PersonForLoginDto ();
  ngOnInit(): void {}

  login(form: NgForm) {
    console.log(this.model.Email);
    console.log(this.model.Password);
    console.log(this.authService.login(this.model));
  }

}
