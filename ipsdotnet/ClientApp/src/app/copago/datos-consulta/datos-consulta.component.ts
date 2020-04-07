import { Component, OnInit } from '@angular/core';
import { Datos } from '../models/datos';
import { DatosService } from '../../services/datos.service';
import {Observable, of} from 'rxjs';

@Component({
  selector: 'app-datos-consulta',
  templateUrl: './datos-consulta.component.html',
  styleUrls: ['./datos-consulta.component.css']
})
export class DatosConsultaComponent implements OnInit {

  listaDatos:Datos[];
  searchText:string;
  constructor(private datosServicio: DatosService) { }

  ngOnInit(): void {

    this.get();
    
  }

  get(){

    this.datosServicio.get().subscribe(result => {
      this.listaDatos = result;
    });
  }

}
