import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TodoEntryComponent } from "./components/todo-entry/todo-entry.component";
import { TodoListComponent } from "./components/todo-list/todo-list.component";
import { TodosDataService } from "src/app/services/todos-data.service";

@Component({
  standalone: true,
  template: `
    <section>
      <app-todo-entry />
    </section>
    <section>
      <app-todo-list
        [items]="todoItems()"
        message="Here is all the stuff you have to do!"
      />
    </section>
  `,
  styleUrls: ["./todos.component.css"],
  imports: [CommonModule, TodoEntryComponent, TodoListComponent],
})
export class TodosComponent {
  todoItems = this.service.getItems();
  sayThis = "Demo Header";

  constructor(private readonly service: TodosDataService) {}
}
