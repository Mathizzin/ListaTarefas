import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tarefa-cadastrar',
  templateUrl: './tarefa-cadastrar.component.html',
  styleUrls: ['./tarefa-cadastrar.component.css'],
})

export class TarefaCadastrarComponent {
  formularioTarefa: FormGroup;
  carregando: boolean = false;
  erroAoCadastrar: boolean = false;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) {
    this.formularioTarefa = this.formBuilder.group({
      descricao: ['', Validators.required],
      concluida: [false],
      usuarioId: ['', Validators.required]
    });
  }

  cadastrarTarefa() {
    if (this.formularioTarefa.invalid) {
      return;
    }

    this.carregando = true;
    const novaTarefa = this.formularioTarefa.value;

    this.httpClient.post('https://localhost:7101/api/tarefa/', novaTarefa).subscribe(
      () => {
        this.formularioTarefa.reset();
        this.carregando = false;
        this.erroAoCadastrar = false;
      },
      (erro) => {
        console.error('Erro ao cadastrar tarefa', erro);
        this.erroAoCadastrar = true;
        this.carregando = false;
      }
    );
  }
}
