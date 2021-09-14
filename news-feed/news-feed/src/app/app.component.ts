import { UserService } from './user.service';
import { Component } from '@angular/core';
import { User } from './user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'news-feed';
  user: User[] = [];

  constructor( private userService: UserService){

  }

  ngOnInit(): void {

  }
}
