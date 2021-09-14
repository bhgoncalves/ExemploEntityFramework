import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { faTrashAlt, faPlus } from '@fortawesome/free-solid-svg-icons';
import { User } from '../user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(public userService: UserService) { }

  faTrashAlt = faTrashAlt;
  faPlus = faPlus;
  
  ngOnInit(): void {
    this.userService.getAllUsers();
  }

  selectUser( user:User){
    this.userService.formData = Object.assign({}, user);
    this.userService.isNew = false
  }

  createUser(){
    this.userService.formData = new User();
    this.userService.list.push(this.userService.formData);
    this.userService.isNew = true;
  }

  deleteUser(cpf: string){
    if(this.userService.isNew){
      this.userService.list.pop();
      return;
    }
    this.userService.deleteUser(cpf);
  }

}
