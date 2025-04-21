document.addEventListener('DOMContentLoaded', function () {

  // Payment Method Pie Chart
  const pieCtx = document.getElementById('paymentPieChart').getContext('2d');
  new Chart(pieCtx, {
    type: 'pie',
    data: {
      labels: ['Cash', 'Check', 'Credit', 'Insurance-Direct'],
      datasets: [{
        label: 'Payment Methods',
        data: [4, 2, 6, 3],
        backgroundColor: ['#f39c12', '#3498db', '#2ecc71', '#e74c3c']
      }]
    },
    options: {
      responsive: true,
      plugins: {
        legend: { position: 'bottom' }
      }
    }
  });

  // Bill Status Bar Chart
  const barCtx = document.getElementById('billStatusBarChart').getContext('2d');
  new Chart(barCtx, {
    type: 'bar',
    data: {
      labels: ['Paid', 'Partially Paid', 'Unpaid'],
      datasets: [{
        label: 'Bill Status Count',
        data: [7, 2, 3],
        backgroundColor: ['#2ecc71', '#f1c40f', '#e74c3c']
      }]
    },
    options: {
      responsive: true,
      scales: {
        y: { beginAtZero: true }
      }
    }
  });

  // Revenue Growth Line Chart with Range Selection
  const revenueCtx = document.getElementById("revenueLineChart").getContext("2d");
  const revenueRangeSelect = document.getElementById("revenueRange");

  function generateDummyRevenue(days) {
    const today = new Date();
    const labels = [];
    const data = [];

    for (let i = days - 1; i >= 0; i--) {
      const date = new Date(today);
      date.setDate(today.getDate() - i);
      labels.push(date.toISOString().split('T')[0]); // YYYY-MM-DD
      data.push(Math.floor(Math.random() * 500) + 100);
    }

    return { labels, data };
  }

  let revenueData = generateDummyRevenue(30);

  let revenueChart = new Chart(revenueCtx, {
    type: 'line',
    data: {
      labels: revenueData.labels,
      datasets: [{
        label: "Revenue",
        data: revenueData.data,
        backgroundColor: "rgba(0,140,186,0.2)",
        borderColor: "rgba(0,140,186,1)",
        borderWidth: 2,
        fill: true,
        tension: 0.3
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        y: {
          beginAtZero: true,
          ticks: {
            callback: value => `$${value}`
          }
        }
      }
    }
  });

  revenueRangeSelect.addEventListener("change", function () {
    const days = parseInt(this.value);
    const updated = generateDummyRevenue(days);
    revenueChart.data.labels = updated.labels;
    revenueChart.data.datasets[0].data = updated.data;
    revenueChart.update();
  });

});

// Payments by Insurance Provider Chart
const insuranceCtx = document.getElementById("insurancePaymentsChart").getContext("2d");
const insuranceRange = document.getElementById("insuranceRange");

const providers = ["Blue Cross", "Aetna", "Cigna", "Medicare", "Self-pay"];

function generateInsurancePayments() {
  return providers.map(() => Math.floor(Math.random() * 3000) + 500);
}

let insuranceChart = new Chart(insuranceCtx, {
  type: 'bar',
  data: {
    labels: providers,
    datasets: [{
      label: "Total Payments ($)",
      data: generateInsurancePayments(),
      backgroundColor: '#008cba'
    }]
  },
  options: {
    responsive: true,
    maintainAspectRatio: false,
    scales: {
      y: {
        beginAtZero: true,
        ticks: {
          callback: value => `$${value}`
        }
      }
    }
  }
});

insuranceRange.addEventListener("change", () => {
  insuranceChart.data.datasets[0].data = generateInsurancePayments();
  insuranceChart.update();
});
