import { Categoria } from "./Categoria.models";

export interface Tarefa {
    tarefaId: number;
    descricao?: string;
    concluida: boolean;
    categoria?: Categoria;
  }

