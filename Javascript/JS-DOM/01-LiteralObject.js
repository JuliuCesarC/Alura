const user = {
	name: "Jão da Silva",
	email: "jao@jaomail.com",
	birth: "02/07/1955",
	employed: true,
	showInfos: function(){
		console.log(this.name, this.email);
	}
}

const admin = {
	name: "Jenfiner",
	email: "jeje@jemail.com",
	role: "admin",
	createPost: ()=>{
		console.log("post criado");
	}
}

Object.setPrototypeOf(admin, user)

admin.createPost()
admin.showInfos()