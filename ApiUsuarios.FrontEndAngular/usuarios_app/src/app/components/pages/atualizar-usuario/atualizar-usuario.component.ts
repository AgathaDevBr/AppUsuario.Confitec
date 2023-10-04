import { Component, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from 'src/environment/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-atualizar-usuario',
  templateUrl: './atualizar-usuario.component.html',
  styleUrls: ['./atualizar-usuario.component.css']
})
export class AtualizarUsuarioComponent {

  @Input() idUsuario!: string;

  mensagem_sucesso : string = '';
  mensagem_erro: string = '';
  escolaridades: any[] = [];
  httpHeaders: HttpHeaders = new HttpHeaders();
  
 //construtor
 constructor(
  private httpClient: HttpClient,
  private spinner: NgxSpinnerService,
  private activatedRoute: ActivatedRoute
  ){

    this.activatedRoute.paramMap.subscribe(params => {
      const id = params.get('id');
      this.formAtualizarUsuario.value.idUsuario = id; // Atribui o valor do ID ao idUsuario
    });

    this.httpClient.get(
      environment.apiUsuarios + "/listar-escolaridades",
      { headers: this.httpHeaders } //enviando o token..
    )
      .subscribe({
        next: (data) => {
          this.escolaridades = data as any[];
        },
        error: (e) => {
          this.mensagem_erro = e.error.mensagem;
        }
      })
      .add(
        () => {
          this.spinner.hide();
        }
      )
      
    let id = this.activatedRoute.snapshot.paramMap.get('id') as string;
    
    this.httpClient.get(
      environment.apiUsuarios + '/' + id,
    )
      .subscribe({
        next: (data: any) => {
          this.formAtualizarUsuario.patchValue(data);
          this.formAtualizarUsuario.controls['idEscolaridade'].setValue
                     (data.escolaridade.idEscolaridade);
        },
        error: (e) => { //capturando a resposta de erro
          this.mensagem_erro = e.error.Message;
          console.log(e.error);
        }
      })
      .add(
        () => {
          this.spinner.hide();
        }
      )
  }

 //objeto para capturar o formulário
  formAtualizarUsuario = new FormGroup({
    nome: new FormControl('', [
      Validators.required, Validators.maxLength(20), Validators.minLength(5)
    ]),
    sobrenome: new FormControl('',[
      Validators.required, Validators.maxLength(100), Validators.minLength(5)
    ]),

    email: new FormControl('',[
      Validators.required, Validators.email, Validators.maxLength(50)
    ]),

    dataNascimento: new FormControl('',[
      Validators.required
    ]),

    idEscolaridade: new FormControl('',[
      Validators.required
    ]),

      idUsuario: new FormControl('',[
        Validators.required
      ])
  });

  //objeto para executar as validações dos csmpos
  get form(): any {
    return this.formAtualizarUsuario.controls;
  }

  //função para submit para processar o formulário
  onSubmit(): void {
    this.spinner.show();

    this.mensagem_sucesso = '';
    this.mensagem_erro = '';

    this.httpClient.put(
      environment.apiUsuarios + "/atualizar-usuario",
      this.formAtualizarUsuario.value,
      { headers: this.httpHeaders } //enviando o token..
    )
      .subscribe({
        next: (data: any) => {
          this.mensagem_sucesso = data.mensagem;
        },
        error: (e) => { //capturando a resposta de erro
          this.mensagem_erro = e.error.Message;
          console.log(e.error);
        }
      })
      .add(
        () => {
          this.spinner.hide();
        }
      )

  }

}


