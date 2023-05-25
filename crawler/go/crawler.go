package main

import (
	"bufio"
	"bytes"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"os"
	"path/filepath"
	"regexp"
	"strings"
)

type Nota struct {
	File string   `json:"file"`
	URL  []string `json:"url"`
}

func main() {

	var notas []Nota
	err := filepath.Walk(".", func(path string, info os.FileInfo, err error) error {
		if err != nil {
			fmt.Println("Error:", err)
			return nil
		}

		var links []string
		if !info.IsDir() && strings.HasSuffix(info.Name(), ".txt") {
			newLinks := getLinks(path)
			if len(newLinks) > 0 {
				for _, link := range newLinks {
					links = append(links, link)
				}
			}

			var nota = Nota{path, links}
			notas = append(notas, nota)
		}

		return nil
	})

	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	jsonData, err := json.MarshalIndent(notas, "", "    ")
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	err = ioutil.WriteFile("result.json", jsonData, 0644)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	fmt.Println("Links found:", len(notas))
	fmt.Println("Results saved to result.json")

	//postData(jsonData)
}

func postData(jsonData []byte) {
	url := "https://example.com/api/endpoint" // Replace with your API endpoint

	resp, err := http.Post(url, "application/json", bytes.NewBuffer(jsonData))
	if err != nil {
		fmt.Println("Error posting data:", err)
		return
	}

	defer resp.Body.Close()

	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		fmt.Println("Error reading response body:", err)
		return
	}

	fmt.Println("API response:", string(body))
}

func getLinks(filename string) []string {
	var links []string

	file, err := os.Open(filename)
	if err != nil {
		fmt.Println("Error opening file:", err)
		return links
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()
		re := regexp.MustCompile(`(?:^|\s)((http|https|ftp):\/\/(localhost)(:\d+)?(\/[\w.-]*)*(\?[\w\.\-_\[\]=&]*)?)(?:$|\s)|(((http(s)?)|ftp):\/\/)?[\w.-]+\.[a-zA-Z]{2,}(\/[\w.-]*)*(\?[\w\.\-_\[\]=&#]*)?(#[\w\.\-_\[\]=&#]*)?`)
		matches := re.FindAllString(line, -1)
		for _, match := range matches {
			links = append(links, match)
		}
	}
	if err := scanner.Err(); err != nil {
		fmt.Println("Error scanning file:", err)
	}

	return links
}
