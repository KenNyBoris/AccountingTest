import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CreatePositionModel } from 'src/app/models/position/create-position.model';
import { MatDialogRef } from '@angular/material/dialog';
import { PositionService } from 'src/app/services/position.service';

@Component({
  selector: 'app-create-position',
  templateUrl: './create-position.component.html',
  styleUrls: ['./create-position.component.scss']
})
export class CreatePositionComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<CreatePositionComponent>,
    private positionService: PositionService) {
    this.positionModel = new CreatePositionModel();
   }
  public createPositionForm: FormGroup;
  public positionModel: CreatePositionModel;

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.createPositionForm = new FormGroup({
      positionName: new FormControl(this.positionModel.name, Validators.required)
    })
  }

  private get getPositionName() { return this.createPositionForm.controls.positionName.value; }

  public cancel(): void {
    this.dialogRef.close();
  }

  public createPosition(): void {
    if(!this.createPositionForm.valid) {
      return;
    }
    
    this.positionModel.name = this.getPositionName;
    this.dialogRef.close(this.positionModel);
  }
}
