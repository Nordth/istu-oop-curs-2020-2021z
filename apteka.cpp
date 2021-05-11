#include <iostream>
#include <iomanip>
#include <vector>
#include <map>

class Firm {

private:
	std::string name;
	std::string address;

public:
	Firm() {}

	Firm(const std::string name, const std::string address) {
		this->name = name;
		this->address = address;
	}

	std::string getName() { return name; }
	std::string getAddress() { return address; }
};

class Med {

private:
	std::string name;
	std::string producer_name;
	std::string provider_name;
	std::string group_name;
	int price;

public:
	Med() {}

	Med(const std::string name, int price, 
	const std::string group_name,
	const std::string producer_name,
	const std::string provider_name) {
		this->name = name;
		this->price = price;
		this->group_name = group_name;
		this->producer_name = producer_name;
		this->provider_name = provider_name;
	}
	std::string getName() { return name; }
	std::string getProducerName() { return producer_name; }
	std::string getProviderName() { return provider_name; }
	std::string getGroupName() { return group_name; }
	int getPrice() { return price; };
};

class Group {
public:
	std::string name;
	std::map<std::string, int> med_count;
	std::map<std::string, int> med_sold;
public:
	Group() {}

	Group(const std::string name) {
		this->name = name;
	}
};

class Pharmacy {

private:
	std::map<std::string, Firm> producers;
	std::map<std::string, Firm> providers;
	std::map<std::string, Med> meds;
	std::map<std::string, Group> groups;

public:
	Pharmacy() {
		downloadData();
	}
	
	void downloadData() {
		producers["Factory1"] = Firm("Factory1", "S.Peterburg");
		producers["Factory2"] = Firm("Factory2", "Moscow");
		
		providers["Provider1"] = Firm("Provider1", "Vologda");
		providers["Provider2"] = Firm("Provider2", "Novgorod");

		groups["Anesthetize"] = Group("Anesthetize");
		groups["Antiviral"] = Group("Antiviral");
		groups["Antiallergenic"] = Group("Antiallergenic");

		meds["Analgin Factory1 Provider1"] = Med(
								"Analgin", 7, "Anesthetize",
								"Factory1", "Provider1");

		meds["Citromon Factory2 Provider1"] = Med(
								"Citromon", 10, "Anesthetize",
								"Factory2", "Provider1");
	}

	void addGroup(const std::string group_name) {
		groups[group_name] = Group(group_name);
	}

	void addProvider(const std::string provider_name, const std::string address) {
		providers[provider_name] = Firm(provider_name, address);
	}

	void addProducer(const std::string producer_name, const std::string address) {
		producers[producer_name] = Firm(producer_name, address);
	}

	bool addMed(
	const std::string name, 
	int price, 
	const std::string group_name,
	const std::string producer_name,
	const std::string provider_name
	) {
		if (meds.find(name) != meds.end()) {
			return false;
		}
		if (providers.find(provider_name) == providers.end()) {
			return false;
		}
		if (producers.find(producer_name) == producers.end()) {
			return false;
		}
		if (groups.find(group_name) == groups.end()) {
			return false;
		}
		meds[name + " " + producer_name + " " + provider_name] = Med(name, 
			price, group_name, producer_name, provider_name);
		return true;
	}

	bool arrivalMedicament(std::string med_name, int count,
	std::string provider_name, std::string producer_name) {
		std::string med_full_name;
		med_full_name = med_name + " " + producer_name + " " + provider_name;
		if (meds.find(med_full_name) == meds.end()) {
			return false;
		}
		std::string group_name = meds[med_full_name].getGroupName();
		if (groups[group_name].med_count.find(med_full_name) == 
		groups[group_name].med_count.end()) {
			groups[group_name].med_count[med_full_name] = count;
		} else {
			groups[group_name].med_count[med_full_name] += count;
		}
		return true;
	}

	void printReserveReport() {
		std::map<std::string, Group>::iterator group_it;
		for (group_it = groups.begin(); group_it != groups.end(); ++group_it) {
			std::cout << "Group name: ";
			std::cout << group_it->first << std::endl;
			std::map<std::string, int>::iterator med_it;
			if (group_it->second.med_count.size() == 0) {
				std::cout << "\tNot medicaments\n";
				continue;
			}
			med_it = group_it->second.med_count.begin();
			for ( ; med_it != group_it->second.med_count.end(); ++med_it) {
				std::cout << "\t" << meds[med_it->first].getName();
				std::cout << ": " << med_it->second << std::endl;
			}
		} 
		std::cout << std::endl;
	}

	bool saleMedicament(std::string med_name, int sale_count,
	std::string provider_name, std::string producer_name) {
		std::string med_full_name = med_name + " " + producer_name + " " + provider_name;
		if (meds.find(med_full_name) == meds.end()) {
			return false;
		}
		std::string group_name = meds[med_full_name].getGroupName();
		if (groups[group_name].med_count[med_full_name] < sale_count) {
			sale_count = groups[group_name].med_count[med_full_name];
			groups[group_name].med_count[med_full_name] = 0;
		} else {
			groups[group_name].med_count[med_full_name] -= sale_count;
		}
		if (groups[group_name].med_sold.find(med_full_name) == groups[group_name].med_sold.end()) {
			groups[group_name].med_sold[med_full_name] = sale_count;
		} else {
			groups[group_name].med_sold[med_full_name] += sale_count;
		}
		return true;
	}

	void printSaleReport() {
		std::map<std::string, Group>::iterator group_it;
		for (group_it = groups.begin(); group_it != groups.end(); ++group_it) {
			std::cout << "Group name: ";
			std::cout << group_it->first << std::endl;
			std::map<std::string, int>::iterator med_it;
			if (group_it->second.med_sold.size() == 0) {
				std::cout << "\tNot sales\n";
				continue;
			}
			med_it = group_it->second.med_sold.begin();
			for ( ; med_it != group_it->second.med_sold.end(); ++med_it) {
				std::cout << "\t" << meds[med_it->first].getName();
				std::cout << ": " << med_it->second * meds[med_it->first].getPrice() << " RUB\n";
			}
		} 
		std::cout << std::endl;
	}

	bool printInvoiceReport(std::string provider_name) {
		int sum = 0, count = 0, width = 15, col = 4;
		if (providers.find(provider_name) == providers.end()) {
			return false;
		}
		std::cout << "Provider name: " << provider_name << std::endl;
		std::cout << "Provider addres: " << providers[provider_name].getAddress() << std::endl;
		std::cout.width(width); std::cout << "Medicaments";
		std::cout.width(width); std::cout << "Price";
		std::cout.width(width); std::cout << "Count";
		std::cout.width(width); std::cout << "Sum\n";
		std::cout.fill('-');
		std::cout.width(width * col); std::cout << "" << std::endl;
		std::cout.fill(' ');
		std::map<std::string, Group>::iterator group_it;
		for (group_it = groups.begin(); group_it != groups.end(); ++group_it) {
			std::map<std::string, int>::iterator med_it;
			if (group_it->second.med_count.size() == 0) {
				continue;
			}
			med_it = group_it->second.med_count.begin();
			for ( ; med_it != group_it->second.med_count.end(); ++med_it) {
				if (meds[med_it->first].getProviderName() == provider_name) {
					std::cout.width(width); std::cout << meds[med_it->first].getName();
					std::cout.width(width); std::cout << meds[med_it->first].getPrice();
					int buf = med_it->second + group_it->second.med_sold[med_it->first];
					std::cout.width(width); std::cout << buf;
					count += buf;
					buf *= meds[med_it->first].getPrice();
					std::cout.width(width); std::cout << buf << std::endl;
					sum += buf;
				}
			}
		} 
		std::cout.fill('-');
		std::cout.width(width * col); std::cout << "" << std::endl;
		std::cout.fill(' ');
		std::cout.width(width * (col - 1)); std::cout << count;
		std::cout.width(width); std::cout << sum;
		std::cout << std::endl;
		std::cout.fill(' ');
		return true;
	}
};

int main()
{
	Pharmacy* pharmacy = new Pharmacy();

	std::string med_name;
	std::string group_name;
	std::string producer_name;
	std::string provider_name;
	std::string address;
	int price, count;
	bool fl;
	while (true) {
		std::cout << "Write '1' - add new medicament\n";
		std::cout << "Write '2' - add new group\n";
		std::cout << "Write '3' - add new provider\n";
		std::cout << "Write '4' - add new producer\n";
		std::cout << "Write '5' - arrival medicaments\n";
		std::cout << "Write '6' - sale medicaments\n";
		std::cout << "Write '7' - print reserve report\n";
		std::cout << "Write '8' - print sale report\n";
		std::cout << "Write '9' - print invoice report\n";
		std::cout << "Write '0' - exit\n";
		int key_code;
		std::cin >> key_code;
		if (key_code == 1) {
			std::cout << "Medicament name: "; std::cin >> med_name;
			std::cout << "Price: "; std::cin >> price;
			std::cout <<"Provider name: "; std::cin >> provider_name;
			std::cout <<"Producer name: "; std::cin >> producer_name;
			fl = pharmacy->addMed(med_name, price, group_name, 
			producer_name, provider_name);
			if (!fl) {
				std::cout << "Incorrect data, write again\n";
			}
		}
		if (key_code == 2) {
			std::cout << "Write group name\n"; std::cin >> group_name;
			pharmacy->addGroup(group_name);
		}
		if (key_code == 3) {
			std::cout << "Write provider name\n"; std::cin >> provider_name;
			std::cout << "Write address\n"; std::cin >> address;
			pharmacy->addProvider(provider_name, address);
		}
		if (key_code == 4) {
			std::cout << "Write producer name\n"; std::cin >> producer_name;
			std::cout << "Write address\n"; std::cin >> address;
			pharmacy->addProducer(producer_name, address);
		}
		if (key_code == 5 || key_code == 6) {
			while (true) {
				std::cout << "Write medicament name or q to exit\n";
				std::cin >> med_name;
				if (med_name == "q") {
					break;
				}
				std::cout << "Write count: "; std::cin >> count;
				std::cout <<"Provider name: "; std::cin >> provider_name;
				std::cout << "Write producer: "; std::cin >> producer_name;
				if (key_code == 5) {
					fl = pharmacy->arrivalMedicament(med_name, count,
						provider_name, producer_name);
				} else {
					fl = pharmacy->saleMedicament(med_name, count,
						provider_name, producer_name);
				}
				if (!fl) {
					std::cout << "Incorrect data, write again\n";
				}
			}
		}
		if (key_code == 7) {
			pharmacy->printReserveReport();
		}
		if (key_code == 8) {
			pharmacy->printSaleReport();
		}
		if (key_code == 9) {
			std::cout << "Write provier name\n";
			std::cin >> provider_name;
			pharmacy->printInvoiceReport(provider_name);
		}
		if (key_code == 0) {
			break;
		}
	}
	return 0;
}