import { TipoCategoriaEnum } from "./enums/tipo-categoria.model"

export interface Categoria {
    Id: string
    Descricao: string
    Tipo: TipoCategoriaEnum
}