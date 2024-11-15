const max_point = 501
let round = 1;
let now_throw_player = 1;
let now_throw_count = 1;
let players = [[]];

let table = document.createElement('table');
var tr = document.createElement('tr');
var tr1 = document.createElement('tr');
append_cell(["", "player1"]);
append_cell(["point", max_point]);
table.appendChild(tr);
table.appendChild(tr1);
document.getElementById('score-table').appendChild(table);

function hit(name) {
    let p = name_to_point(name);
    players[round - 1].push(p);
    let total_score = calc_total_score(players);
    table.rows[1].cells[1].firstChild.data = max_point - total_score;

    if (total_score == max_point) {
        alert('finish');
    } else if (total_score > max_point) {
        alert('bust');
        players[round - 1] = [0, 0, 0];
        now_throw_count = 10;
        let total_score = calc_total_score(players);
        table.rows[1].cells[1].firstChild.data = max_point - total_score;
    }

    document.getElementById("notification-click-event").innerText = players;

    now_throw_count += 1;
    if (now_throw_count > 3) {
        let round_sum = function (arr) {
            let sum = 0;
            for (var i = 0; i < arr.length; i++) {
                sum += arr[i];
            }
            return sum;
        }
        append_cell(["R" + round, round_sum(players[round - 1])]);
        now_throw_count = 1;
        round += 1;
        players.push([]);
    }
};


function name_to_point(name) {
    if (name === "out") {
        return 0;
    } else if (name === "inner-bull" | name === "outer-bull") {
        return 50;
    } else {
        let p = name.split('-');
        let basic_point = parseInt(p[p.length - 1], 10);
        if (p[0] === "triple") {
            return basic_point * 3;
        } else if (p[0] === "double") {
            return basic_point * 2;
        } else {
            return basic_point
        }
    }
}

function calc_total_score(scores) {
    let total = 0;
    for (let i = 0; i < scores.length; i++) {
        for (let l = 0; l < scores[i].length; l++) {
            total += scores[i][l];
        }
    }
    return total;
}

function append_cell(data) {
    var th = document.createElement('th');
    th.textContent = data[0];
    tr.appendChild(th);
    var td = document.createElement('td');
    td.textContent = data[1];
    tr1.appendChild(td);
}