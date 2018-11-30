import { Component } from '@angular/core';
import { ClienteService } from 'src/app/services/Cliente.service';
import { Registro } from 'src/app/modelos/Registro';

@Component({
    selector: 'validador-clientes',
    templateUrl: 'validador-clientes.component.html',
    styleUrls: ['validador-clientes.component.scss']
})
export class ValidadorClientesComponent {
    mensajeError: string;
    constructor(private clienteService: ClienteService) {

    }
    archivoContenido: File = null;
    archivoRegistro: File = null;

    CargarArchivo(files: FileList, tipo) {
        this.mensajeError = ""
        switch (tipo) {
            case "contenido":
                if (files[0].name.toLowerCase() != "contenido.txt") {
                    this.mensajeError = "Debe cargar el archivo contenido.txt";
                    this.archivoContenido = null;
                }
                else { this.archivoContenido = files[0]; }
                break;
            case "registro":
                if (files[0].name.toLowerCase() != "registrados.txt") {
                    this.mensajeError = "Debe cargar el archivo registrados.txt";
                    this.archivoRegistro = null;
                }
                else { this.archivoRegistro = files[0]; }
                break;
            default:
                break;
        }

    }

    Enviar() {
        this.mensajeError = "";
        const formData: FormData = new FormData();
        formData.append('uploadFile', this.archivoContenido, this.archivoContenido.name);
        formData.append('uploadFile', this.archivoRegistro, this.archivoRegistro.name);
        this.clienteService.ValidarClientes(formData).subscribe((resultado) => {
            this.DescargarResultado(resultado);
        }, error => this.mensajeError = "Error en la petición");
    }


    private DescargarResultado(resultado: Registro[]) {
        let Obj = '';
        resultado.forEach(element => {
            Obj += (element.NombreCliente + ' -> ' + (element.Existe ? 'Existe\r\n' : 'No Existe\r\n'));
        });
        Obj = encodeURIComponent(Obj);
        var element = document.createElement('a');
        element.setAttribute('href', 'data:text/plain;charset=utf-8,' + Obj);
        element.setAttribute('download', "Resultado");
        element.style.display = 'none';
        document.body.appendChild(element);
        element.click();
        document.body.removeChild(element);
    }
}
