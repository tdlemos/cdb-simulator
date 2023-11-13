import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators } from '@angular/forms';
import { CalculoCDBRequest, CdbService } from '../Service/cdb.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {
  meses: number | null = 0;
  valorbruto: number | null = null;
  valorliquido: number | null = null;
  valorImposto: number | null = null;
  aliquotaImposto: number | null = null;

  constructor(private cdbService: CdbService) { }

  formFields = new FormGroup({
    meses: new FormControl<number | null>(12, Validators.required),
    valorInicial: new FormControl<number | null>(1000, Validators.required),
  });

  onSubmit(e: any) {
    e.preventDefault();

    const meses =  this.formFields.controls['meses'].value;
    const valorInicial =  this.formFields.controls['valorInicial'].value;

    if(!meses) return;
    if(!valorInicial) return;
    if(meses < 1) return;
    if(valorInicial < 1) return;

    const request: CalculoCDBRequest = {
      ValorInicial: valorInicial,
      Meses: meses
    }

    console.log(request);

    this.cdbService.getPosts(request)
      .subscribe(res => {
        this.meses = meses;
        this.valorbruto = res.valorFinal;
        this.valorliquido = res.valorFinal - res.impostoValor;
        this.valorImposto = res.impostoValor;
        this.aliquotaImposto = res.impostoAliquota;
      });
  }
}
