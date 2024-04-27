import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-account',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.scss'
})

export class CreateAccountComponent implements OnInit {
  formData = {
    username: '',
    password: '',
    lastName: '',
    firstName: '',
    email: '',
    county: '',
    phone: ''
  };

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    // Here you can handle form submission, e.g., send data to a server
    console.log(this.formData);
  }
}