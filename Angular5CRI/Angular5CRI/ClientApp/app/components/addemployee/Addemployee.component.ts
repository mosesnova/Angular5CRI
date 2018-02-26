import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchEmployeeComponent } from '../fetchemployee/fetchemployee.component';
import { EmployeeService } from '../../services/empservice.service';

@Component({
    selector: 'createemployee',
    templateUrl: './AddEmployee.component.html'
})

export class createemployee implements OnInit {
    employeeForm: FormGroup;
    title: string = "Create";
    emp_id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _employeeService: EmployeeService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.emp_id = this._avRoute.snapshot.params["id"];
        }

        this.employeeForm = this._fb.group({
            emp_id: 0,
            emp_name: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.emp_id > 0) {
            this.title = "Edit";
            
        }
    }

    save() {

        if (!this.employeeForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._employeeService.saveEmployee(this.employeeForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-employee']);
                }, error => this.errorMessage = error)
        }
       
    }

    cancel() {
        this._router.navigate(['/fetch-employee']);
    }

    get name() { return this.employeeForm.get('emp_name'); }
}  