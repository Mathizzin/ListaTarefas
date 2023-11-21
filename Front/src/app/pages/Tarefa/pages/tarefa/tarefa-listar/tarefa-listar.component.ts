import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tarefa } from '../../../../../models/Tarefa.models';

@Component({
  selector: 'app-tarefa-listar',
  templateUrl: './tarefa-listar.component.html',
  styleUrls: ['./tarefa-listar.component.css']
})
export class TarefaListarComponent implements OnInit {

  tarefas: Tarefa[] = [];
  carregandoTarefas: boolean = false;
  erroAoCarregar: boolean = false;

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    console.log("O componente foi carregado!");

    // Chame a função para carregar as tarefas aqui
    this.carregarTarefas();
  }

  carregarTarefas(): void {
    // Substitua a URL pela sua URL da API
    const apiUrl = 'https://localhost:7101/api/tarefa/';

    // Indique que o carregamento está em andamento
    this.carregandoTarefas = true;

    // Faça a chamada HTTP para obter as tarefas
    this.httpClient.get<{ $values: Tarefa[] }>(apiUrl).subscribe(
      (response) => {
        if (Array.isArray(response.$values)) {
          this.tarefas = response.$values;
        } else {
          console.error('Formato de resposta da API inválido:', response);
          // Indique que ocorreu um erro
          this.erroAoCarregar = true;
        }
        // Indique que o carregamento foi concluído
        this.carregandoTarefas = false;
      },
      (erro) => {
        console.error('Erro ao carregar tarefas', erro);
        // Indique que ocorreu um erro
        this.erroAoCarregar = true;
        // Indique que o carregamento foi concluído (mesmo que tenha falhado)
        this.carregandoTarefas = false;
      }
    );
  }
}
