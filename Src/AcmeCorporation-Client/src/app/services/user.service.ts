import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private accessInfo: AccessInfo = {
    accessToken: '',
    isLoggedIn: false,
    subjectId: '',
    refreshToken: '',
    errorMessage: '',
  };

  constructor() { }

  login(username: string, passwod): AccessInfo {

    // For testing purposes only
    // this could will be swapped with some implementation of identity server OAUTH implicit flow
    if (username === 'guest' && passwod === 'guest') {
      this.accessInfo.isLoggedIn = true;
    } else {
      this.accessInfo.errorMessage = 'Login failed';
    }

    return this.accessInfo;
  }

  logout(): AccessInfo {

    this.accessInfo.errorMessage = '';
    this.accessInfo.isLoggedIn = false;

    return this.accessInfo;
  }

  getAcccessInfo(): AccessInfo {
    return this.accessInfo;
  }
}


export class AccessInfo {
  accessToken: string;
  refreshToken: string;
  subjectId: string;
  isLoggedIn: boolean;
  errorMessage: string;
}
