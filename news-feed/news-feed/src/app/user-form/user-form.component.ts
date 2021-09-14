import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  constructor(public userService: UserService) { }

  ngOnInit(): void {
  }

  onSubmit(form : any){
    if(this.userService.isNew){
      this.postUser(); 
    } else{
      this.update();
    }
  }

  update(){
    this.userService.updateUser(this.userService.formData);
  }

  getUser(){
    this.userService.getUser(this.userService.formData.cpf);
  }
  postUser(){
    this.userService.postUser();
  }

}
