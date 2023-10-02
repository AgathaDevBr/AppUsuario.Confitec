import { NgModule, CUSTOM_ELEMENTS_SCHEMA   } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from "angular-datatables";
import { NgxPaginationModule } from 'ngx-pagination';
import { NgxSpinnerModule } from "ngx-spinner";
import { Routes, RouterModule } from '@angular/router';

import { CriarUsuarioComponent } from './components/pages/criar-usuario/criar-usuario.component';
import { ListaTodosComponent } from './components/pages/lista-todos/lista-todos.component';
import { AtualizarUsuarioComponent } from './components/pages/atualizar-usuario/atualizar-usuario.component';

const routes: Routes = [ 
  { path: '', pathMatch: 'full', redirectTo: 'pages/lista-todos' },
  { path: 'pages/criar-usuario', component: CriarUsuarioComponent},
  { path: 'pages/lista-todos', component: ListaTodosComponent},
  { path: 'pages/atualizar-usuario/:id', component: AtualizarUsuarioComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CriarUsuarioComponent,
    ListaTodosComponent,
    AtualizarUsuarioComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes), //registrando as rotas
    HttpClientModule, 
    NgxPaginationModule,
    FormsModule,
    ReactiveFormsModule,
    DataTablesModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
