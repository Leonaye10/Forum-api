import { Comment } from "./comment";

export class Topic {

    idTopic: Number;
    titre: string;
    nomUtilisateur: string;
    dateCreation: Date;
    dateModification?: Date;
    comments: Comment[];

    constructor(idTopic: Number, titre: string, nomUtilisateur: string, dateCreation: Date, dateModification: Date, comments: Comment[]){
        this.idTopic = idTopic;
        this.titre = titre;
        this.nomUtilisateur = nomUtilisateur;
        this.dateCreation = dateCreation;
        this.dateModification = dateModification;
        this.comments = comments;
    }

}