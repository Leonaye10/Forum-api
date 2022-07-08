
export class Comment {

    idComment: Number;
    nomUtilisateur: string;
    contenu: string;
    dateCreation: Date;
    dateModification?:  Date;
    topicId: Number;

    constructor(idComment: Number, nomUtilisateur: string, contenu: string, dateCreation: Date, dateModification: Date, topicId: Number){
        this.idComment = idComment;
        this.nomUtilisateur = nomUtilisateur;
        this.contenu = contenu;
        this.dateCreation = dateCreation;
        this.dateModification = dateModification;
        this.topicId = topicId;
    }

}