import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '../../../node_modules/@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  userName: '';
  password: '';
  errorMessage: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    console.log(this.userName + ' ' + this.password);
    const accessInfo = this.userService.login(this.userName, this.password);
    if (accessInfo.isLoggedIn) {
      this.router.navigateByUrl('/report'); // Should be routed to the place from where it was refered
      return;
    } else {
      alert(accessInfo.errorMessage);
    }
  }
}
