import { Component, Input } from '@angular/core';
import { TipoMovimentacaoEnum } from '../../../finance/movimentacao/models/tipoMovimentacao.model';
import { CommonModule } from '@angular/common'

@Component({
  selector: 'tipo-movimentacao-column-template',
  standalone: true,
  imports: [
    CommonModule
  ],
  // styleUrl: './TipoMovimentacao.Column.Template.component.scss',
  templateUrl: './TipoMovimentacao.Column.Template.component.html',
})
export class TipoMovimentacaoColumnTemplateTsComponent { 
  
  protected getStyle(): String {
    return this.style
  }

  private _tipoMovimentacao!: TipoMovimentacaoEnum
  protected style: string = ''
  protected texto: string = ''

  @Input() 
  set tipoMovimentacao(value: TipoMovimentacaoEnum) {
    
    this._tipoMovimentacao = value

    switch (value) {
      case TipoMovimentacaoEnum.Despesa:
        this.style = 'tag-despesa'
        this.texto = 'Despesa'
        break
    
      case TipoMovimentacaoEnum.Receita:
        this.style = 'tag-receita'
        this.texto = 'Receita'
        break

      case TipoMovimentacaoEnum.Transferencia:
        this.style = ''
        this.texto = 'Transferencia'
        break

      default:
        break
    }

    console.log(`${this.texto}: ${this.style}`)
  }
}
