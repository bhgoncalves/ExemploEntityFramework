import { User } from './user';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  BASE_URL = "https://localhost:44381/api/Users/"
  constructor(private httpClient: HttpClient) { }

  public list : User[] = [];
  public formData : User = new User();
  public isNew : boolean = false;
  
  getAllUsers(){
    this.httpClient.get<User[]>(this.BASE_URL ).subscribe((data) =>{
      console.log(data);
      this.list = data;
    })
  }

  getUser(cpf : string)
  {
    return this.httpClient.get<User>(this.BASE_URL+ `/${cpf}`) 
  }

  postUser(){
    return this.httpClient.post(this.BASE_URL, this.formData).subscribe( _ => {
      this.getAllUsers();
    });
  }

  updateUser(user:User){
    return this.httpClient.put<User>(this.BASE_URL+ `/${user.cpf}`, user).subscribe( _ => {
      this.getAllUsers();
    }); 
  }

  deleteUser(cpf:string){
    return this.httpClient.delete<User>(this.BASE_URL+ `/${cpf}`).subscribe(_ => {
      this.getAllUsers();
    })
  }


}
