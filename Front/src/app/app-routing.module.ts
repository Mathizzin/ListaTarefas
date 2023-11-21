// app-routing.module.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TarefaListarComponent } from './pages/Tarefa/pages/tarefa/tarefa-listar/tarefa-listar.component'
import { TarefaCadastrarComponent } from './pages/Tarefa/pages/tarefa/tarefa-cadastrar/tarefa-cadastrar.component'; // Importe o componente correto

const routes: Routes = [
  { path: '', component: TarefaListarComponent }, // Rota padrão para o componente TarefaListarComponent
  { path: 'CadastrarTarefa', component: TarefaCadastrarComponent }, // Rota para o componente CadastrarTarefaComponent
  // Adicione mais rotas conforme necessário
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
