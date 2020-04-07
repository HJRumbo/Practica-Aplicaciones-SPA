import { Component, OnInit } from '@angular/core';
import { Datos } from '../models/datos';
import { DatosService } from 'src/app/services/datos.service';

@Component({
  selector: 'app-datos-registro',
  templateUrl: './datos-registro.component.html',
  styleUrls: ['./datos-registro.component.css']
})
export class DatosRegistroComponent implements OnInit {

  datos: Datos;
  constructor(private datosServicio: DatosService) { }

  ngOnInit(): void {
    this.datos = new Datos();
  }

  add(){

    this.datosServicio.post(this.datos).subscribe(d => {
      if(d != null){
        alert('Datos guardados!');
        this.datos = d;
      }else{
        alert('Error!');
      }
    })
  }

}
