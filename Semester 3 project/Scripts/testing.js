// Demo 1

const quizContainer = document.getElementById('choices');
const questionContainer = document.getElementById('question');
const startButton = document.getElementById('start');
const questNo = document.getElementById('question-number')
const sel = document.querySelector('.sel');
const cardHeader = document.querySelector('.card-header');
const nxtBtn = document.querySelector('.nxtBtn');
const prvBtn = document.querySelector('.prvBtn');
const nextButton = document.getElementById('next');
const timerElement = document.getElementById('timer');
const opts = document.querySelectorAll('.option');    
const opt1 = document.querySelector('.option1');
const opt2 = document.querySelector('.option2');
const opt3 = document.querySelector('.option3');
const opt4 = document.querySelector('.option4');

let i = 0;
let score = 0;
let timer;
let timeLeft = 120;
let optArr = new Array(10);   //there was no need of this.
let correctOpt = [4, 4, 2, 3, 1, 4, 4, 2, 3, 1];   
let selectedOpt = new Array(10);

const questions = [
    {
      question: "You or I as a child of God,____ to prosper.",
      choices: ["is", "has", "are", "am"],
      answer: "am",
    },
    {
      question: "None of you ____ righteous.",
      choices: ["is", "was", "has ever been", "are"],
      answer: "are",
    },
    {
      question: "None of them ____ righteous; said Ade.",
      choices: ["were", "is", "are", "have ever been"],
      answer: "is",
    },
    {
      question: "Seventy percent of the problem ____ solved.",
      choices: ["have been", "has being", "has been", "have being"],
      answer: "has been",
    },
    {
      question: "John welcomed his guests ____ offered them drinks.",
      choices: ["and", "while", "until", "as"],
      answer: "and",
    },
    {
      question: "You or I as a child of God,____ to prosper.",
      choices: ["is", "has", "are", "am"],
      answer: "am",
    },
    {
      question: "None of you ____ righteous.",
      choices: ["is", "was", "has ever been", "are"],
      answer: "are",
    },
    {
      question: "None of them ____ righteous; said Ade.",
      choices: ["were", "is", "are", "have ever been"],
      answer: "is",
    },
    {
      question: "Seventy percent of the problem ____ solved.",
      choices: ["have been", "has being", "has been", "have being"],
      answer: "has been",
    },
    {
      question: "John welcomed his guests ____ offered them drinks.",
      choices: ["and", "while", "until", "as"],
      answer: "and",
    },
];

function startQuiz() {
  startButton.style.display = 'none';
  sel.style.display = 'none';
  nxtBtn.classList.remove('hide')
  prvBtn.classList.remove('hide')
  quizContainer.classList.remove('hide')
  cardHeader.style.display = 'block';
  cardHeader.classList.remove('d-none')
  timerElement.style.display = 'block';
  timer = setInterval(updateTimer, 1000);
  showQuestion();
}



function showQuestion() {
  update();
}



// function checkAnswer(answer) {
//   if (answer === questions[i].answer) {
//     score++;
//   }
// }

function update(){
  if(i==1) prvBtn.classList.remove("hide");
  if(i==0){
    prvBtn.classList.add("disabled");
  }else{
    prvBtn.classList.remove("disabled");
  }
  if (i === questions.length) {
    endQuiz();
  }
  
  if(i==9) nxtBtn.innerHTML = 'End';
  if(i==0) nxtBtn.innerHTML = 'Next';
 
        




  
      questionContainer.innerText = questions[i].question;
      questNo.innerHTML = (i+1);

      
      opt1.innerText = questions[i].choices[0]
      opt2.innerText = questions[i].choices[1]
      opt3.innerText = questions[i].choices[2];
      opt4.innerText = questions[i].choices[3];
      opts.forEach(opt => {
        opt.addEventListener('click', () =>{
          if(opt.innerText === questions[i].answer){
            console.log(questions[i].answer);
            score++
          }
        })
      });
      i++
}

function updatePrv(){
  i--;
  i--;
  update();
}


function endQuiz() {
  clearInterval(timer);
  questionContainer.innerText = `You got ${score} out of ${questions.length} questions correct!`;
  quizContainer.innerHTML = '';
  nxtBtn.style.display = 'none';
  prvBtn.style.display = 'none';
}


function updateTimer() {
  timeLeft--;
  timerElement.innerText = `Time left: ${timeLeft} seconds`;
  if (timeLeft <= 0) {
    clearInterval(timer);
    endQuiz();
  }
}

startButton.addEventListener('click', startQuiz);
nxtBtn.addEventListener('click', update)
prvBtn.addEventListener('click', updatePrv)