import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    // baseUrl = environment.baseUrl;
    constructor() { }

    authUser(user: any ) {

      let UserArray = [];
      if (localStorage.getItem('Users')) {

        UserArray = JSON.parse(localStorage.getItem('Users'));
}

//console.log(UserArray);
      // tslint:disable-next-line: triple-equals
      return UserArray.find(p => p.userName === user.userName && p.password === user.password);
      //  return this.http.post(this.baseUrl + '/account/login', user);

    }





}
