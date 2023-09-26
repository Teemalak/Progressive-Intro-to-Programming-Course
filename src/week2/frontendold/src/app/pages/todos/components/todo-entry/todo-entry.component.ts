import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import {
  PrimaryButtonDirective,
  SecondaryButtonDirective,
} from "src/app/ui/primary-button.directive";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";

@Component({
  selector: "app-todo-entry",
  standalone: true,
  imports: [
    CommonModule,
    PrimaryButtonDirective,
    SecondaryButtonDirective,
    ReactiveFormsModule,
  ],
  template: `
    <form>
      <label for="item">Item</label>
      <input type="text" class="input input-primary" id="item" />
      <button appSecondaryButton>Add Item</button>
    </form>
  `,
  styles: [],
})
export class TodoEntryComponent {
  form = new FormGroup({
    item: new FormControl<string>("Buy Beer"),
  });
}
