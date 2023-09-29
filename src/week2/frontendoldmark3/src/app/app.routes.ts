import { Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { SupportComponent } from "./pages/support/support.component";
import { TodosComponent } from "./pages/todos/todos.component";
import { AdminComponent } from "./pages/admin/admin.component";
import { CounterComponent } from "./pages/counter/counter.component";

export const routes: Routes = [
  {
    path: "dashboard",
    component: HomeComponent,
  },
  {
    path: "support",
    component: SupportComponent,
  },
  {
    path: "todos",
    component: TodosComponent,
  },
  {
    path: "admin",
    loadComponent: () =>
      import("./pages/admin/admin.component").then((c) => c.AdminComponent),
  },
  {
    path: "counter",
    component: CounterComponent,
  },
  {
    path: "**",
    redirectTo: "dashboard",
  },
];
