import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
	providedIn: 'root'
})
export class AppService {
	
	private tituloBehavior = new BehaviorSubject<string>('LagControl');
	private navegacaoBehavior = new BehaviorSubject<string[]>([]);

	titulo$ = this.tituloBehavior.asObservable();
	navegacao$ = this.navegacaoBehavior.asObservable();

	definirTitulo(titulo: string) {
	  this.tituloBehavior.next(titulo);
	}

	definirNevagacao(navegacao: string[]) {
		this.navegacaoBehavior.next(navegacao);
	  }
}