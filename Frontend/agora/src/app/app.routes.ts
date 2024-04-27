import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CreatePetitionComponent } from './create-petition/create-petition.component';
import { ListOfPetitionsComponent } from './list-of-petitions/list-of-petitions.component';
import { CreateAccountComponent } from './create-account/create-account.component';
import { UsersComponent } from './users/users.component';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' }, 
    { path: 'Login', component: LoginComponent },
    { path: 'Petitii', component: ListOfPetitionsComponent },
    { path: 'Deleaga-votul', component: UsersComponent },
    { path: 'Creeaza-petitie', component: CreatePetitionComponent },
    { path: 'Creare-cont', component: CreateAccountComponent }
];
