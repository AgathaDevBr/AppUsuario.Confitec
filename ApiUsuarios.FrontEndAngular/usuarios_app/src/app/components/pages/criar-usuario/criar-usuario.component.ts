import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';
import { NgxSpinnerService, Spinner } from 'ngx-spinner';


@Component({
  selector: 'app-criar-usuario',
  templateUrl: './criar-usuario.component.html',
  styleUrls: ['./criar-usuario.component.css']
})
export class CriarUsuarioComponent {

  mensagem_sucesso : string = '';
  mensagem_erro: [] = [];
  escolaridades: any[] = [];

  //construtor
  constructor(
  private httpClient: HttpClient,
  private spinner: NgxSpinnerService
  ){

    this.httpClient.get(
      environment.apiUsuarios + "/listar-escolaridades"
    )
      .subscribe({
        next: (data) => {
          this.escolaridades = data as any[];
        },
        error: (e) => {
          console.log(e); 
          this.mensagem_erro = e.error.mensagem;
        }
      })
  }

  //criando um formulário..
  formCriarUsuario = new FormGroup({

        nome: new FormControl('', [
            Validators.required, Validators.maxLength(20)
        ]),

        sobrenome: new FormControl('',[
          Validators.required, Validators.maxLength(100)
        ]),

        email: new FormControl('',[
          Validators.required, Validators.email, Validators.maxLength(50)
        ]),

        dataNascimento: new FormControl('',[
          Validators.required
        ]),

        idEscolaridade: new FormControl('',[
          Validators.required
        ])

    });
    

   get form(): any {
    return this.formCriarUsuario.controls;
    }

    //função para capturar o evento SUBMIT
    //do formulário
    onSubmit(): void {

      this.spinner.show();

      //fazendo uma requisição POST para a API
      this.httpClient.post(
        environment.apiUsuarios + '/adicionar-usuario' ,
      this.formCriarUsuario.value)
      .subscribe({
        next: (data: any) => { //capturando a resposta de sucesso
        this.mensagem_sucesso = data.mensagem;
        this.formCriarUsuario.reset(); //limpando o formulário
        },
      error: (e) => { //capturando a resposta de erro
        this.mensagem_erro = e.error;
      }
    })  
    .add(
      () => {
        this.spinner.hide();
      }
    )
  };
}