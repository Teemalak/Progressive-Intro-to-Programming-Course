import { Component, Input } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TodoItem } from "src/app/services/todos-data.service";
import { ToggleOnOffComponent } from "src/app/ui/toggle-on-off.component";

@Component({
  selector: "app-todo-list",
  standalone: true,
  imports: [CommonModule, ToggleOnOffComponent],
  template: `
    <h2 class="text-2xl">{{ message }}</h2>
    <ul>
      <li *ngFor="let item of items">
        <span [ngClass]="{ completed: item.completed }">{{
          item.description
        }}</span>

        <app-toggle-on-off *ngIf="item.completed === false" />
      </li>
    </ul>
  `,
  styleUrls: ["./todos.component.css"],
})
export class TodoListComponent {
  @Input({ required: true }) items: TodoItem[] = [];
  @Input() message = "Your todo List";
}
