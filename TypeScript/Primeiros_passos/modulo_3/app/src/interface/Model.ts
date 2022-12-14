import { Printable } from "../utils/Printable";
import { Comparable } from "./Comparable.js";

// Uma interface pode ser estendidas de varias outras, isso permite implementarmos esta interface em uma classe, sem que a mesma seja obrigada a implementar diversas outras interfaces, pois todas estas ja foram estendidas nesta Interface.
export interface Model<T> extends Printable, Comparable<T>{}